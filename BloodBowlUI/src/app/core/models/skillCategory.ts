import { Skill } from "./skill";

export interface SkillCategory {
    Id: number;
    ShortName: string;
    Name: string;
    Skills: Skill[];
}