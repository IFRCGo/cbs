import convertDate from "./convertDate";

const formatDate = report => {
  let date = convertDate(report.Timestamp);
  date = new Date(date);
  date = date.toLocaleString("default", {
    month: "short",
    day: "numeric",
    hour: "2-digit",
    minute: "2-digit"
  });
  return date;
};

export default formatDate;
