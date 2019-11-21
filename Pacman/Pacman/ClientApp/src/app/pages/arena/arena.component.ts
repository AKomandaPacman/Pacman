import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Player } from 'src/app/models/Player.model';
import { Item } from 'src/app/models/Item.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { interval } from 'rxjs';
import { forkJoin } from 'rxjs';
import { forEach } from 'lodash-es';


@Component({
    selector: 'xn-arena',
    templateUrl: './arena.component.html',
    styleUrls: ['./arena.component.less']
})


export class ArenaComponent implements OnInit {

    currentPlayerPosX: number = <number>{};
    currentPlayerPosY: number = <number>{};
    player: Player = <Player>{};
    itemsAll: Item[] = <Item[]>{};
    itemsFetched: Item[] = <Item[]>[{ id: 0, type: "1", posX: 0, posY: 0 }];
    updatedX: number = <number>{};
    updatedY: number = <number>{};
    levelRows: number = 9;
    levelCols: number = 16;
    tileSize: number = 25;
    imageFile: string = "";


    constructor(private builder: FormBuilder, private http: HttpClient) {
        this.funcGet();
    }


    funcGet() {

        let getPlayers = this.http.get<Player>(`${environment.backend_url}/Players/1`);
        let getItems = this.http.get<Item[]>(`${environment.backend_url}/Items`);

        forkJoin([getPlayers, getItems]).subscribe(results => {
            this.currentPlayerPosX = results[0].posX;
            this.currentPlayerPosY = results[0].posY;
            this.imageFile = results[0].image;
            this.player = results[0];
            this.itemsFetched = results[1];
        });
    }

    funcUpdate(x, y) {

        if ((x == null) || (y == null)) {
            x = 4; y = 5;
        }

        this.player.posX = x;
        this.player.posY = y;
        this.player.id = 1;

        //veliau sitiems irgi imti reiksmes is parametru
        this.player.boosted = false;
        this.player.ghost = false;
        this.player.score = 2;
        this.player.name = "nickYellow";


        this.http
            .put<Player>(`${environment.backend_url}/Players/1`, this.player)
            .subscribe();
    }

    drawItems(context, canvas, contextInfo, levelRows, levelCols, level, tileSize) {

        // clear the canvas
        context.clearRect(0, 0, canvas.width, canvas.height);
        contextInfo.clearRect(0, 0, canvas.width, canvas.height);

        // walls
        for (var i = 0; i < levelRows; i++) {
            for (var j = 0; j < levelCols; j++) {
                if (level[i][j] == 1)
                    context.fillStyle = "#072649";
                else if (level[i][j] == 0)
                    context.fillStyle = "#000000";
                else if (level[i][j] == 2)
                    context.fillStyle = "#ADD8E6";
                    

                context.fillRect(j * tileSize, i * tileSize, tileSize, tileSize);
            }
        }

        Array.prototype.forEach.call(this.itemsFetched, it => {

            let tileSizeItem = 11;

            if (it.type == "0") { context.fillStyle = "#FFFFFF"; tileSizeItem = 7; }
            else if (it.type == "1")
                context.fillStyle = "#F39C12";
            else if (it.type == "2")
                context.fillStyle = "#48C9B0";
            else if (it.type == "3")
                context.fillStyle = "#7409FB";
            else if (it.type == "4")
                context.fillStyle = "#B11C47";


            context.fillRect(it.posX, it.posY, tileSizeItem, tileSizeItem);
        });
    }



    ngOnInit() {

        this.funcGet();
        interval(100).subscribe(x => {
            this.funcGet();
        });


        //---------------------------------------------------------------------------------------STRATEGY PATTERN
        var Movement = function () {
            this.direction = "";
        };

        Movement.prototype = {
            setStrategy: function (direction) {
                this.direction = direction;
            },

            move: function (pressed) {
                return this.direction.move(pressed);
            }
        };

        var UP = function () {
            this.move = function (pressed) {
                if (pressed)
                    upPressed = true;
                else upPressed = false;
            }
        };

        var DOWN = function () {
            this.move = function (pressed) {
                if (pressed)
                    downPressed = true;
                else downPressed = false;
            }
        };

        var RIGHT = function () {
            this.move = function (pressed) {
                if (pressed)
                    rightPressed = true;
                else rightPressed = false;
            }
        };

        var LEFT = function () {
            this.move = function (pressed) {
                if (pressed)
                    leftPressed = true;
                else leftPressed = false;
            }
        };

        // the 4 strategies
        var up = new UP();
        var down = new DOWN();
        var left = new LEFT();
        var right = new RIGHT();

        var movement = new Movement();
        //---------------------------------------------------------------------------------------STRATEGY PATTERN END




        var canvas = <HTMLCanvasElement>document.getElementById("canvas");   // the canvas where game will be drawn
        var context = canvas.getContext("2d");            // canvas context
        var canvasInfo = <HTMLCanvasElement>document.getElementById("canvasInfo");   // the canvas where game will be drawn
        var contextInfo = canvasInfo.getContext("2d");            // canvas context
        var tileSize = 20;							// tile size, in pixels
        var playerCol = 5;                                  // player starting column
        var playerRow = 4;                                  // player starting row
        var playerYPos = playerRow * tileSize;				// converting Y player position from tiles to pixels
        var playerXPos = playerCol * tileSize;               // converting X player position from tiles to pixels
        var leftPressed = false;                            // are we pressing LEFT arrow key?
        var rightPressed = false;                           // are we pressing RIGHT arrow key?
        var upPressed = false;                              // are we pressing UP arrow key?
        var downPressed = false;                            // are we pressing DOWN arrow key?
        var movementSpeed = 1;                              // the speed we are going to move, in pixels per frame
        var playerXSpeed = 0;                               // player horizontal speed, in pixels per frame
        var playerYSpeed = 0;                               // player vertical speed, in pixels per frame
        var isGhost = false;


        var mapNumber = Math.floor(Math.random() * 2) + 1;
        var fileName = "../../../assets/maps/map" + mapNumber.toString() + ".txt";
        //var fileName = "../../../assets/maps/map2.txt";

        var allText = "";
        var file = new XMLHttpRequest();
        file.open("GET", fileName, false);
        file.onreadystatechange = function () {
            if (file.readyState === 4) {
                if (file.status === 200 || file.status == 0) {
                    allText = file.responseText;
                }
            }
        }
        file.send(null);

        var textLines = allText.split('\n');
        var colsRows = textLines[0].split(':');
        var levelCols = parseInt(colsRows[0]);        // level width, in tiles
        var levelRows = parseInt(colsRows[1]);        // level height, in tiles


        var level = [];
        for (var i = 1; i < levelRows + 1; i++) {
            var rowNumbers = textLines[i].split(',');
            level[i - 1] = [];
            for (var j = 0; j < levelCols; j++) {
                level[i - 1][j] = parseInt(rowNumbers[j]);
            }
        }

        for (var i = 0; i < levelRows; i++) {
            for (var j = 0; j < levelCols; j++) {
                if (level[i][j] == 1) {
                    var randomIndex = Math.floor(Math.random() * 12) + 1;
                    if (randomIndex == 1)
                        level[i][j] = 2;
                }
            }
        }



        interval(100).subscribe(x => {
            this.funcUpdate(playerXPos, playerYPos);
        });

        interval(1).subscribe(x => {
            this.drawItems(context, canvas, contextInfo, levelRows, levelCols, level, tileSize);

            // player
            //context.fillStyle = "#fff200";
            //context.fillRect(playerXPos, playerYPos, tileSize, tileSize);

           

            if (isGhost) {   //if (this.isGhost)
                const base_image = new Image();
                base_image.src = 'assets/g_pink.png';
                context.drawImage(base_image, playerXPos, playerYPos, tileSize, tileSize);
            }
            else {
                const base_image = new Image();
                //base_image.src = this.player.image;
                base_image.src = this.imageFile;
                //base_image.src = 'assets/p_yellow.png';
                context.drawImage(base_image, playerXPos, playerYPos, tileSize, tileSize);
                let dataUrl = canvas.toDataURL('image/png');

                contextInfo.font = "15px Arial";
                contextInfo.fillStyle = "#fff200";
                contextInfo.fillText(this.imageFile, 50, 150);
            }
        });


        canvas.width = tileSize * levelCols;      //1000             // canvas width. Won't work without it even if you style it from CSS
        canvas.height = tileSize * levelRows;                   // canvas height. Same as before



        // simple WASD listeners

        document.addEventListener("keydown", function (e) {
            console.log(e.keyCode);
            switch (true) {
                case ((e.keyCode === 37) || (e.keyCode === 65)):
                    movement.setStrategy(left);                             //------------STRATEGY PATTERN SETTING
                    movement.move(true);                                    //------------STRATEGY PATTERN EXECUTION
                    break;
                case ((e.keyCode === 38) || (e.keyCode === 87)):
                    movement.setStrategy(up);
                    movement.move(true);
                    break;
                case ((e.keyCode === 39) || (e.keyCode === 68)):
                    movement.setStrategy(right);
                    movement.move(true);
                    break;
                case ((e.keyCode === 40) || (e.keyCode === 83)):
                    movement.setStrategy(down);
                    movement.move(true);
                    break;
            }
        }, false);

        document.addEventListener("keyup", function (e) {
            switch (true) {
                case ((e.keyCode === 37) || (e.keyCode === 65)):
                    movement.setStrategy(left);
                    movement.move(false);
                    break;
                case ((e.keyCode === 38) || (e.keyCode === 87)):
                    movement.setStrategy(up);
                    movement.move(false);
                    break;
                case ((e.keyCode === 39) || (e.keyCode === 68)):
                    movement.setStrategy(right);
                    movement.move(false);
                    break;
                case ((e.keyCode === 40) || (e.keyCode === 83)):
                    movement.setStrategy(down);
                    movement.move(false);
                    break;
            }
        }, false);


        function renderLevel() {

            contextInfo.font = "30px Arial";
            contextInfo.fillStyle = "#fff200";
            contextInfo.fillText(playerXPos.toString() + ";" + playerYPos.toString(), 50, 50);
        }


        // this function will do its best to make stuff work at 60FPS - please notice I said "will do its best"

        window.requestAnimationFrame = (function (callback) {
            return window.requestAnimationFrame || window.webkitRequestAnimationFrame || (<any>window).mozRequestAnimationFrame || (<any>window).oRequestAnimationFrame || (<any>window).msRequestAnimationFrame ||
                function (callback) {
                    window.setTimeout(callback, 1000 / 60);
                };
        })();

        // function to handle the game itself

        function updateGame() {
            // no friction or inertia at the moment, so at every frame initial speed is set to zero
            playerXSpeed = 0;
            playerYSpeed = 0;


            // updating speed according to key pressed
            if (rightPressed) {
                playerXSpeed = movementSpeed;
            }
            else {
                if (leftPressed) {
                    playerXSpeed = -movementSpeed;
                }
                else {
                    if (upPressed) {
                        playerYSpeed = -movementSpeed;
                    }
                    else {
                        if (downPressed) {
                            playerYSpeed = movementSpeed;
                        }
                    }
                }
            }




            // updating player position
            playerXPos += playerXSpeed;
            playerYPos += playerYSpeed;


            //---------------------------------------------------------------------------------------COMMAND PATTERN
            function goUp() { playerYPos = baseRow * tileSize; }
            function goUpUndo(value) { playerYPos = baseRow * tileSize - value; }
            function goDown() { playerYPos = (baseRow + 1) * tileSize; }
            function goDownUndo(value) { playerYPos = (baseRow + 1) * tileSize + value; }
            function goRight() { playerXPos = baseCol * tileSize; }
            function goRightUndo(value) { playerXPos = baseCol * tileSize - value; }
            function goLeft() { playerXPos = (baseCol + 1) * tileSize; }
            function goLeftUndo(value) { playerXPos = (baseCol + 1) * tileSize + value; }

            var Command = function (execute, undo, value) {
                this.execute = execute;
                this.undo = undo;
                this.value = value;
            }

            var UpCommand = function (value) {
                return new Command(goUp, goUpUndo, value);
            };

            var DownCommand = function (value) {
                return new Command(goDown, goDownUndo, value);
            };

            var LeftCommand = function (value) {
                return new Command(goLeft, goLeftUndo, value);
            };

            var RightCommand = function (value) {
                return new Command(goRight, goRightUndo, value);
            };

            var Commander = function () {
                var commands = [];

                return {
                    execute: function (command) {
                        command.execute(command.value);
                        commands.push(command);
                    },

                    undo: function () {
                        var command = commands.pop();
                        command.undo(command.value);
                    }
                }
            }
            var commander = Commander();
            //---------------------------------------------------------------------------------------COMMAND PATTERN END



            //---------------------------------------------------------------------------------------ADAPTER PATTERN
            //------------------------OLD INTERFACE
            function AnyPlayer() {
                this.checkColisions = function (type) {
                    if (type == "horizontal") {
                        if (playerXSpeed > 0) {
                            if ((level[baseRow][baseCol + 1] && !level[baseRow][baseCol]) || (level[baseRow + 1][baseCol + 1] && !level[baseRow + 1][baseCol] && rowOverlap)) {
                                commander.execute(RightCommand(30));            //-------------------COMMAND PATTERN EXECUTION
                            }
                        }

                        if (playerXSpeed < 0) {
                            if ((!level[baseRow][baseCol + 1] && level[baseRow][baseCol]) || (!level[baseRow + 1][baseCol + 1] && level[baseRow + 1][baseCol] && rowOverlap)) {
                                commander.execute(LeftCommand(30));          //-------------------COMMAND PATTERN EXECUTION
                            }
                        }
                    }
                    else if (type == "vertical") {
                        if (playerYSpeed > 0) {
                            if ((level[baseRow + 1][baseCol] && !level[baseRow][baseCol]) || (level[baseRow + 1][baseCol + 1] && !level[baseRow][baseCol + 1] && colOverlap)) {
                                commander.execute(UpCommand(30));          //-------------------COMMAND PATTERN EXECUTION
                            }
                        }

                        if (playerYSpeed < 0) {
                            if ((!level[baseRow + 1][baseCol] && level[baseRow][baseCol]) || (!level[baseRow + 1][baseCol + 1] && level[baseRow][baseCol + 1] && colOverlap)) {
                                commander.execute(DownCommand(30));          //-------------------COMMAND PATTERN EXECUTION
                            }
                        }
                    }
                }
            }
            


            //any player (ghost, pacman) can move in 4 directions, only pacman player is affected by special tiles
            //------------------------NEW INTERFACE
            function PacmanPlayer() {
                this.checkSpecialTileColision = function (type) {
                    if (type == "horizontal") {
                        if (playerXSpeed > 0) {
                            if ((level[baseRow][baseCol + 1] == 2 && !level[baseRow][baseCol]) || (level[baseRow + 1][baseCol + 1] == 2 && !level[baseRow + 1][baseCol] && rowOverlap)) {
                                commander.undo();                               //-------------------COMMAND PATTERN UNDO RIGHT
                            }
                        }

                        if (playerXSpeed < 0) {
                            if ((!level[baseRow][baseCol + 1] && level[baseRow][baseCol] == 2) || (!level[baseRow + 1][baseCol + 1] && level[baseRow + 1][baseCol] == 2 && rowOverlap)) {
                                commander.undo();                       //-------------------COMMAND PATTERN UNDO LEFT
                            }
                        }
                    }
                    else if (type == "vertical") {
                        if (playerYSpeed > 0) {
                            if ((level[baseRow + 1][baseCol] == 2 && !level[baseRow][baseCol]) || (level[baseRow + 1][baseCol + 1] == 2 && !level[baseRow][baseCol + 1] && colOverlap)) {
                                commander.undo();                    //-------------------COMMAND PATTERN UNDO UP
                            }
                        }

                        if (playerYSpeed < 0) {
                            if ((!level[baseRow + 1][baseCol] && level[baseRow][baseCol] == 2) || (!level[baseRow + 1][baseCol + 1] && level[baseRow][baseCol + 1] == 2 && colOverlap)) {
                                commander.undo();           //-------------------COMMAND PATTERN UNDO DOWN
                            }
                        }
                    }
                }
            }

            //------------------------ADAPTER INTERFACE
            function PlayerAdapter() {
                var pacman = new PacmanPlayer();

                return {
                    checkColisions: function (type) {
                        pacman.checkSpecialTileColision(type);
                    }
                };
            }
            
            //---------------------------------------------------------------------------------------ADAPTER PATTERN END







            // check for horizontal collisions
            var baseCol = Math.floor(playerXPos / tileSize);
            var baseRow = Math.floor(playerYPos / tileSize);
            var colOverlap = playerXPos % tileSize;
            var rowOverlap = playerYPos % tileSize;
            var directionType = "horizontal";

            //----------------------------------------ADAPTER EXECUTION
            var player = new AnyPlayer();
            var playerPacman = PlayerAdapter();

            if (isGhost) {
                player.checkColisions(directionType);
            }
            else {
                player.checkColisions(directionType);
                playerPacman.checkColisions(directionType);
            }
            

            // check for vertical collisions
            baseCol = Math.floor(playerXPos / tileSize);
            baseRow = Math.floor(playerYPos / tileSize);
            colOverlap = playerXPos % tileSize;
            rowOverlap = playerYPos % tileSize;
            directionType = "vertical";

            //----------------------------------------ADAPTER EXECUTION
            if (isGhost) {
                player.checkColisions(directionType);
            }
            else {
                player.checkColisions(directionType);
                playerPacman.checkColisions(directionType);
            }




            // rendering level

            renderLevel();

            // update the game in about 1/60 seconds

            requestAnimationFrame(function () {
                updateGame();
            });
        }

        updateGame();

    }

}