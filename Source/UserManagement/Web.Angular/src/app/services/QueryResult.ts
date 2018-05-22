export class QueryResult {
    queryName: string;
    totalItems: number;
    items: ReadonlyArray<any>;
    exception: any;
    securityMessages: any[];
    brokenRules: any[];
    passedSecurity: boolean;
    success: boolean;
    invalid: boolean;
}
