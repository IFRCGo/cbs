import { MockCommandCoordinator } from "../mocking/MockCommandCoordinator";
import { MockQueryCoordinator } from "../mocking/MockQueryCoordinator";

export const environment = {
  production: false,
  api: '/reporting',
  commandCoordinatorType: MockCommandCoordinator,
  queryCoordinatorType: MockQueryCoordinator
};
