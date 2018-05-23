export class QueryResult<T> {
    queryName: string;
    totalItems: number;
    items: ReadonlyArray<T>;
    exception: any;
    securityMessages: any[];
    brokenRules: any[];
    passedSecurity: boolean;
    success: boolean;
    invalid: boolean;
}
