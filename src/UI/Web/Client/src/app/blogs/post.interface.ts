export interface Post 
{
    id: number;
    username: string;
    title: string;
    description: string;
    content: string;
    views: number;
    articles: number;
    type: number;
    createdate?: Date;
    publishDate?: Date;
}