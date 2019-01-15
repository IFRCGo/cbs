export default class ReportStatus {
  static get Success() {
    return 0;
  }

  static get TextMessageParsingError() {
    return 1;
  }

  static get UnknownDataCollector() {
    return 2;
  }

  static get TextMessageParsingErrorAndUnknownDataCollector() {
    return 3;
  }

  static isSuccess(status) {
    return status === ReportStatus.Success ||
      status === ReportStatus.UnknownDataCollector;
  }

  static isOriginStatus(status) {
    return status === ReportStatus.UnknownDataCollector ||
      status === ReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
  }
}
