import React from "react";

interface ButtonProps {
  onClick?: () => void;
  color: "blue" | "green" | "red" | "gray";
  outlined?: boolean;
  size: "sm" | "md" | "lg";
  type?: "button" | "submit" | "reset";
  disabled?: boolean;
  children: React.ReactNode;
  LeftIcon?: React.ReactNode;
  RightIcon?: React.ReactNode;
}

const Button: React.FC<ButtonProps> = ({
  onClick,
  color = "blue",
  outlined = false,
  size = "md",
  type = "button",
  disabled = false,
  children,
  LeftIcon,
  RightIcon,
}) => {
  // Define Tailwind CSS classes based on props
  const colorClasses = {
    blue: "bg-blue-500 hover:bg-blue-600",
    green: "bg-green-500 hover:bg-green-600",
    red: "bg-red-500 hover:bg-red-600",
    gray: "bg-gray-500 hover:bg-gray-600",
  };

  const outlinedClasses = outlined ? "border-2" : "";
  const sizeClasses = {
    sm: "text-sm px-4 py-2",
    md: "text-base px-6 py-3",
    lg: "text-lg px-8 py-4",
  };

  return (
    <button
      className={`flex items-center justify-center gap-2 text-white font-semibold rounded transition duration-200 ease-in-out ${
        outlinedClasses ? "border" : ""
      } ${colorClasses[color]} ${sizeClasses[size]} ${
        disabled ? "opacity-50 cursor-not-allowed" : ""
      }`}
      onClick={onClick}
      type={type}
      disabled={disabled}
    >
      {LeftIcon && <span>{LeftIcon}</span>}
      {children}
      {RightIcon && <span>{RightIcon}</span>}
    </button>
  );
};

export default Button;
