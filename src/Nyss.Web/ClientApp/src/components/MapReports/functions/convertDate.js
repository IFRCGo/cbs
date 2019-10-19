const convertDate = str => {
  str = str.split(" ")[0];
  str = str.split("/");
  // Tricks because i have a lot of "Invalid Date"
  const date = new Date(`${str[2]}-${str[1]}-${str[0]}`);
  return date.getTime();
};

export default convertDate;
