import React from 'react';

export default props => {
  let maybeMessage = null;

  if (props.message) {
    maybeMessage = <p>{props.message}</p>;
  }

  return (
    <section id={props.id} className="error">
      <h2>{props.title}</h2>
      {maybeMessage || 'The page you are looking for doesn\'t exist.'}
    </section>
  );
};
