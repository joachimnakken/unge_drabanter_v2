import Button from "components/atoms/Button";
import Input from "components/atoms/Input";

export default function RegisterPage() {
  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const name = data.get("Name");
    const username = data.get("Username");
    const phone = data.get("Phone");
    const address = data.get("Address");
    const city = data.get("City");
    const zip = data.get("Zip");
    const country = data.get("Country");
    const birthday = data.get("Birthday");
    const email = data.get("Email");
    const password = data.get("Password");
    const confirmPassword = data.get("Confirm Password");

    console.log(
      data,
      name,
      username,
      phone,
      address,
      city,
      zip,
      country,
      birthday,
      email,
      password,
      confirmPassword
    );
  };

  // Should use formik or something like that

  return (
    <main>
      <h1>Register</h1>
      <form onSubmit={handleSubmit}>
        <Input label="Name" name="Name" type="text" />
        <Input label="Username" name="Username" type="text" />
        <Input label="Phone" name="Phone" type="tel" />
        <Input label="Address" name="Address" type="text" />
        <Input label="City" name="City" type="text" />
        <Input label="Zip" name="Zip" type="text" />
        <Input label="Country" name="Country" type="text" />
        <Input label="Birthday" name="Birthday" type="date" />

        <Input label="Email" name="Email" type="email" />
        <Input label="Password" type="password" name="Password" />
        <Input
          label="Confirm Password"
          type="password"
          name="Confirm Password"
        />
        <div className="flex justify-end gap-2 pt-4">
          <Button color="gray" type="reset" size="lg">
            Reset
          </Button>
          <Button type="submit" color="green" size="lg">
            Register
          </Button>
        </div>
      </form>
    </main>
  );
}
