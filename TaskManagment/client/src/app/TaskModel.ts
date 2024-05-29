export interface TaskModel {
    
    dateCreated: Date | null;
    taskName: string;
    taskDescription: string;
    taskStatus: boolean;
    id: number | null;
}