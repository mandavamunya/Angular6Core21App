import { Post } from './post.interface';

export interface Blog {
    id: number;
    name: string;
    isPublished: boolean;
    createDate: Date;
    publishDate: Date;  
    posts?: Post[]; 
}