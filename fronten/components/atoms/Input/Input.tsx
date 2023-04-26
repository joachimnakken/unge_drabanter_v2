import React, { InputHTMLAttributes } from "react";

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  label: string;
  name: string;
  error?: string;
}

const Input: React.FC<InputProps> = ({
  type,
  placeholder,
  value,
  onChange,
  className,
  label,
  id,
  name,
  required,
  disabled,
  error,
  ...props
}) => {
  return (
    <div className="flex flex-col">
      {/* Add label if provided */}
      {label && (
        <label htmlFor={id} className="mb-1 text-sm font-bold text-gray-700">
          {label}
        </label>
      )}
      {/* Input field */}
      <input
        type={type}
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        className="px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-gray-200 focus:border-transparent"
        id={id}
        name={name}
        required={required}
        disabled={disabled}
        {...props}
      />
      {/* Error message */}
      {error && <p className="mt-1 text-xs text-red-500">{error}</p>}
    </div>
  );
};

export default Input;
