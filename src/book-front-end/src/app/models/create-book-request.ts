export interface CreateBookRequest {
    title: string;
    value: number;
    purchaseForm: string;
    authorIds: string[];
    subjectIds: string[];
}