import { Skill } from "./skill";

export interface PlayerType {
    id: number,
    name: string,
    maximumAllowedOnTeam: number,
    cost: number,
    move: number,
    strength: number,
    agility: number,
    armourValue: number,
    startingSkills: Skill[]
}