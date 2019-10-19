const sexAndAge = report => {
  if (report.NumberOfMalesUnder5 > 0) return `Male/Below 5`;
  if (report.NumberOfMalesAged5AndOlder > 0) return `Male/5 or more`;
  if (report.NumberOfFemalesUnder5 > 0) return `Female/Below 5`;
  if (report.NumberOfFemalesAged5AndOlder > 0) return `Female/5 or more`;
};

export default sexAndAge;
