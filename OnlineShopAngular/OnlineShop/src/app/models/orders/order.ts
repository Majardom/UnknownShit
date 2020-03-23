import { Stage } from './stage';

export interface Order {
    Id: number;
    DateOfCreation: string;
    StageId: number;
    ProductId: number;
    ProductPrice: number;
    Amount: number;
}