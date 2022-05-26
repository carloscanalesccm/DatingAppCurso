export interface Pagination {
    currentPage: number;
    itemsPerGame: number;
    totalItems: number;
    totalPages: number;
}

export class PaginatedResult<T> { // T es un array de miembros 
    result: T;
    pagination: Pagination;
}