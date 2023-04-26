import Button from "components/atoms/Button";
import Input from "components/atoms/Input";

export default function LoginPage() {
  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const email = data.get("Email");
    const password = data.get("Password");

    console.log(data, email, password);
  };

  // Should use formik or something like that

  return (
    <main>
      <h1>Login</h1>
      <form onSubmit={handleSubmit} className="flex flex-col gap-4">
        <Input label="Email" name="Email" type="email" />
        <Input label="Password" type="password" name="Password" />
        <Button size="lg" color="gray" type="reset">
          Reset
        </Button>
        <Button size="lg" color="green" type="submit">
          Login
        </Button>
      </form>

      <div className="flex justify-center gap-2 pt-4">
        <Button size="lg" color="blue">
          Register
        </Button>
        <Button size="lg" color="red">
          Forgot Password
        </Button>
      </div>
    </main>
  );
}
