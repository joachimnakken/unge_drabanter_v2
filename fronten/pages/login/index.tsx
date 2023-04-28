import Button from "components/atoms/Button";
import FormField from "components/atoms/FormField";
import Link from "next/link";
import { useState } from "react";

import { useForm } from "react-hook-form";

interface IFormInputs {
  email: string;
  password: string;
  phoneNumber: number;
}

export default function LoginPage() {
  const {
    register,
    handleSubmit,
    formState: { errors, dirtyFields },
  } = useForm<IFormInputs>({
    mode: "onChange",
    reValidateMode: "onChange",
    // defaultValues: {
    //   // email: "teeeeest@email.com",
    // },
  });

  const onSubmit = (data: IFormInputs) => {
    alert(JSON.stringify(data));
    return data;
  };

  return (
    <main className="grid">
      <h1>Login</h1>
      <p>Enter your email and password to login</p>
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="flex flex-col gap-4 pt-10"
      >
        <FormField
          register={register}
          label="email"
          type="email"
          placeholder="test@email.com"
          required="Email is required"
          dirty={dirtyFields.email}
          pattern={{
            value: /^\S+@\S+$/i,
            message: "Invalid email",
          }}
          error={errors.email?.message}
        />
        <FormField
          register={register}
          label="password"
          type="password"
          placeholder="123456"
          required="Password is required"
          dirty={dirtyFields.password}
          minLength={{
            value: 6,
            message: "Password must be at least 6 characters",
          }}
          error={errors.password?.message}
        />
        <div className="flex justify-end gap-4">
          <Button size="md" color="gray" type="reset">
            Reset
          </Button>
          <Button size="md" color="green" type="submit">
            Login
          </Button>
        </div>
      </form>

      <div className="flex flex-col items-center justify-center gap-2 pt-4">
        <Link href="/register" className="underline">
          Signup
        </Link>

        <Link href="/forgot-password" className="underline">
          Forgot Password?
        </Link>
      </div>
    </main>
  );
}
