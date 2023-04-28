export default function Eventpage() {
  return (
    <main>
      <h1>Event Page</h1>
      <div>
        <p>Image of event</p>
        <p>Event name</p>
        <p>Event description</p>
        <p>Event date</p>
        <p>Event location</p>
        <p>Event category</p>
        <p>Event host</p>
        <p>Event attendees</p>
        <p>Event items</p>
      </div>
      <div>
        <strong>If user is host</strong>
        <p>Should be able to edit an existing event</p>
        <p>Should be able to delete an existing event</p>
      </div>
      <div>
        <strong>If user is not host</strong>
        <p>Should be able to join an existing event</p>
        <p>Should be able to leave an existing event</p>
      </div>
      <div>
        <p>Guest should be able to click on event items to see details</p>
      </div>
    </main>
  );
}
