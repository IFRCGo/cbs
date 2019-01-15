import moment from 'moment';

/**
 * Return a new sorted array, except with one value bumped to the front. This
 * function does not sort an array in place; a new array is returned.
 *
 * For example:
 *
 * > bumpSort(['group B', 'group A', 'group C', 'control'], 'control');
 * ['control', 'group A', 'group B', 'group C']
 */
export function bumpSort(arr, valueToBump) {
  const arrCopy = arr.slice();
  const valueIndex = arrCopy.indexOf(valueToBump);

  if (valueIndex === -1) {
    return arrCopy.sort();
  }

  const arrOfBumped = arrCopy.splice(valueIndex, 1);
  return arrOfBumped.concat(arrCopy.sort());
}

/**
 * Return true if n is a float.
 *
 * For example:
 *
 * isFloat(5) => false
 * isFloat('John') => false
 * isFloat(3.14) => true
 */
export function isFloat(n) {
  return Number(n) === n && n % 1 !== 0;
}

/**
 * Prettify a number for use in this application. Use toLocaleString, but also
 * force a standard number of decimal places if it's a float.
 *
 * For example:
 *
 * prettifyNumber(5) => 5
 * prettifyNumber(5000) => 5,000
 * prettifyNumber(5000000) => 5,000,000
 * prettifyNumber(3.2) => 3.200
 *     - Assuming process.env.REACT_APP_VALUE_DECIMAL_PLACES === 3
 */
export function prettifyNumber(n) {
  if (isFloat(n)) {
    return n.toLocaleString('en-US', {
      minimumFractionDigits: process.env.REACT_APP_VALUE_DECIMAL_PLACES,
      maximumFractionDigits: process.env.REACT_APP_VALUE_DECIMAL_PLACES,
    });
  }

  return n.toLocaleString('en-US');
}

/**
 * Return a title that can be used in a <title> element, incorporating a
 * subtitle if one is provided.
 */
export function getPageTitle(subtitle) {
  let pageTitle;

  if (subtitle) {
    pageTitle = `${subtitle} | ${process.env.REACT_APP_SITE_TITLE}`;
  } else {
    pageTitle = process.env.REACT_APP_SITE_TITLE;
  }

  return pageTitle;
}

export function parseQueryString(query) {
  return query.split('&').reduce((prev, pair) => {
    let parts = pair.split('=');
    prev[parts[0]] = parts[1];

    return prev;
  }, {});
}

export function formatDate(dateString) {
  return moment(dateString).format('DD.MM.YYYY');
}

export function formateTime(dateString) {
  return moment(dateString).format('HH:mm');
}
