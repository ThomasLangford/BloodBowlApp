import { Skill } from "./skill";

export interface SkillCategory {
    id: number;
    name: string;
    shortname: string;
    skills: Skill[];
}