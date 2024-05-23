export interface TaskModel {
    id: number | null;
    dateCreated: Date | null;
    taskName: string;
    taskDescription: string;
    taskStatus: boolean;
}