export interface UpdateBookRequest {
    id: string;
    title: string;
    value: number;
    purchaseForm: string;
    authorUpdateList: string[];
    subjectUpdateList: string[];
  }