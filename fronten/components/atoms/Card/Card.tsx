import React from "react";

type CardProps = {
  children?: React.ReactNode;
};

const Card = ({ children }: CardProps) => {
  return (
    <div className="overflow-hidden rounded drop-shadow-lg">{children}</div>
  );
};

export default Card;
