import ReportStatus from './ReportStatus';

export default class Filters {
  static applyFilter(data, filterName) {
    const filterItem = Filters[filterName];
    const filterFn = Array.isArray(filterItem) ? filterItem[1] : null;

    return filterFn ? data.filter(filterFn) : data;
  }

  static get List() {
    return {
      get all() {
        return 'All';
      },

      get success() {
        return [
          'Success',
          function(report) {
            return report.status === ReportStatus.Success || report.status === ReportStatus.UnknownDataCollector;
          }
        ];
      },

      get error() {
        return [
          'Data Error',
          function(report) {
            return report.status === ReportStatus.TextMessageParsingError ||
              report.status === ReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
          }
        ];
      },

      get unknownSender() {
        return [
          'Unknown Sender',
          function(report) {
            return report.status === ReportStatus.UnknownDataCollector ||
              report.status === ReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
          }];
      }
    }
  }
}
