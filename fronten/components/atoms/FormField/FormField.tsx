import clsx from "clsx";
import { useEffect, useState } from "react";
import { UseFormRegister, ValidationValue } from "react-hook-form";
import { getInputStatus } from "utils/input";

interface IError {
  value: ValidationValue;
  message: string;
}

interface InputProps {
  label: string;
  register: UseFormRegister<any>;
  required?: string;
  placeholder?: string;
  type?: string;
  maxLength?: IError | undefined;
  minLength?: IError | undefined;
  pattern?: IError;
  error?: string;
  disabled?: boolean;
  dirty?: boolean;
}

const FormField = ({
  label = "",
  register,
  disabled = false,
  required,
  placeholder = "",
  maxLength,
  minLength,
  pattern,
  error,
  type = "text",
  dirty,
}: InputProps) => {
  const currentStatus = getInputStatus(!!dirty, !!error);
  const [inputProps, setInputProps] = useState({});

  const inputStatusStyle = {
    valid: "border-green-500 focus:ring-gray-200",
    error: "border-red-500 focus:ring-gray-200",
    default: "border-gray-700 focus:ring-gray-200",
  };

  useEffect(() => {
    // Not the best solution in the world, but it works for now
    // if someone wants to improve this, feel free to do it :D
    // atleast it should not re-render on every keystroke or something
    let registerProps = {};
    if (required) {
      registerProps = {
        ...registerProps,
        required: required,
      };
    }

    if (maxLength) {
      registerProps = {
        ...registerProps,
        maxLength: maxLength,
      };
    }

    if (minLength) {
      registerProps = {
        ...registerProps,
        minLength: minLength,
      };
    }

    if (pattern) {
      registerProps = {
        ...registerProps,
        pattern: pattern,
      };
    }
    setInputProps(registerProps);
    // bit hacky, but it works :P
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <div className="flex flex-col gap-1">
      <label htmlFor={label} className="capitalize">
        {label}
      </label>
      <input
        placeholder={placeholder}
        type={type}
        className={clsx(
          inputStatusStyle[currentStatus],
          "px-4 py-2 border rounded-md focus:outline-none focus:ring-2 focus:border-transparent"
        )}
        disabled={disabled}
        {...register(label, inputProps)}
      />
      {error && (
        <p role="alert" className="text-red-500">
          {error}
        </p>
      )}
    </div>
  );
};

export default FormField;
