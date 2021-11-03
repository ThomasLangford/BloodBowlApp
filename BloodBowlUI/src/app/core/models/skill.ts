import { SkillCategory } from "./skillCategory";

export interface Skill {
    id: number;
    name: string;
    description: string;
    skillCategory: SkillCategory;
}