import { PlayerType } from "./playerType";

export interface TeamType {
    id: number,
    name: string,
    rerollCost: number,
    apothicary: boolean,
    necromancer: boolean,
    rulesetId: number,
    playerTypes: PlayerType[]
}