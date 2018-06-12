import { QueryRequest } from "../../../services/QueryRequest";

export class AllProjects extends QueryRequest {
    constructor() {
        super('allProjects', 'Read.ProjectFeatures.Queries.AllProjects',{});
    }
}