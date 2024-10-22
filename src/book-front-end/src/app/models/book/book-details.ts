import { Author } from "../author";
import { Subject } from "../subject";

export interface BookDetails {
    id: string;
    title: string;
    value: number;
    purchaseForm: string;
    authorDetails: Author[];
    subjectDetails: Subject[];
  }