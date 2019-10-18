export class Player {
    constructor(
        public id: number,
        public name: string,
        public score: number,
        public posX: number,
        public posY: number,
        public boosted: boolean,
        public ghost: boolean,
    ) { }
}