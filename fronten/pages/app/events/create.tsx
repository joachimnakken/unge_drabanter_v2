import Button from "components/atoms/Button";
import Input from "components/atoms/Input";

export default function EventsPage() {
  return (
    <main>
      <h1>Events Page</h1>
      <p>Create a new event</p>
      <form>
        <Input label="Name" name="name" type="text" />
        <Input label="Description" name="description" type="text" />
        <Input label="Date" name="date" type="date" />
        <Input label="Location" name="location" type="text" />
        <Input label="Category" name="category" type="text" />
        <Input label="Host" name="host" type="text" />
        <Input label="Attendees" name="attendees" type="text" />
        <Input label="Items" name="items" type="text" />
        <div className="flex justify-end pt-4">
          <Button color="green" size="md" type="submit">
            Create
          </Button>
        </div>
      </form>
    </main>
  );
}
