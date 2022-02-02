import { Skill } from "./skill";

export interface SkillCategory {
    id: number;
    shortName: string;
    name: string;
    skills: Skill[];
}