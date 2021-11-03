import { SkillCategory } from "./skillCategory";

export interface Skill {
    Id: number;
    Name: string;
    Description: string;
    SkillCategory: SkillCategory;
}