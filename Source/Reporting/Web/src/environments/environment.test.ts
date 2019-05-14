import { MockCommandCoordinator } from "../mocking/MockCommandCoordinator";
import { MockQueryCoordinator } from "../mocking/MockQueryCoordinator";

export const environment = {
  production: false,
  api: '/reporting',
  commandCoordinatorType: MockCommandCoordinator,
  queryCoordinatorType: MockQueryCoordinator,
  appInsightsInstrumentationKey: '36bdf7e0-884f-4391-8f08-11ebd48b9023'
};
