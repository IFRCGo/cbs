export class QueryRequest {
    nameOfQuery: string;
    generatedFrom: string;
    parameters: any;

    constructor(nameOfQuery: string, generatedFrom: string, parameters: any) {
        this.nameOfQuery = nameOfQuery;
        this.generatedFrom = generatedFrom;
        this.parameters = parameters;
    }
}
