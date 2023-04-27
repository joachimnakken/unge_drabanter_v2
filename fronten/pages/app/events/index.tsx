// staticPaths and staticProps are used for pre-rendering

import Image from "next/image";
import Link from "next/link";

interface Event {
  id: number;
  name: string;
  description: string;
  date: string;
  location: string;
  category: string;
  host: string;
  attendees: string[];
  items: string[];
}

export const getStaticProps = async () => {
  const dummyData = [
    {
      id: 1,
      name: "Event 1",
      description: "This is event 1",
      date: "2021-01-01",
      location: "Location 1",
      category: "Category 1",
      host: "Host 1",
      attendees: ["Attendee 1", "Attendee 2"],
      items: ["Item 1", "Item 2"],
    },
    {
      id: 2,
      name: "Event 2",
      description: "This is event 2",
      date: "2021-01-02",
      location: "Location 2",
      category: "Category 2",
      host: "Host 2",
      attendees: ["Attendee 1", "Attendee 2", "Attendee 3"],
      items: ["Item 4", "Item 5"],
    },
    {
      id: 3,
      name: "Event 3",
      description: "This is event 3",
      date: "2021-01-03",
      location: "Location 3",
      category: "Category 3",
      host: "Host 3",
      attendees: ["Attendee 1", "Attendee 2", "Attendee 3", "Attendee 4"],
      items: ["Item 6", "Item 7"],
    },
  ];

  return {
    props: {
      events: dummyData || [],
    },
  };
};

export default function EventsPage({ events }: { events: Event[] }) {
  console.log("events", events);
  return (
    <main>
      <h1>Events Page</h1>
      <div>
        <p>List of all upcoming events</p>
        <p>Should be able to see details of an event</p>
        <p>Should be able to see all previous events</p>
      </div>
      <div>
        <p>Should be able to create a new event</p>
        <p>Should be able to edit an existing event</p>
        <p>Should be able to delete an existing event</p>
      </div>
      <div>
        <p>Should be able to filter by category</p>
        <p>Should be able to filter by date</p>
        <p>Should be able to filter by location</p>
      </div>

      <section>
        <h2>Upcoming Events</h2>
        <div className="grid grid-cols-12 gap-4 pt-4">
          {events.slice(0, 1).map((event) => (
            <div key={event.id} className="flex col-span-6 ring">
              <div className="relative h-full aspect-square">
                <Image
                  src="https://images.unsplash.com/photo-1615887023544-3a566f29d822?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1287&q=80"
                  alt="event"
                  fill
                />
              </div>
              <div className="flex-1 p-4 ring">
                <p>{event.name}</p>
                <p>{event.description}</p>
                <p>{event.date}</p>
                <p>{event.location}</p>
                <p>{event.category}</p>
                <p>{event.host}</p>
                <div className="flex gap-1">
                  {event.attendees.map((attendee) => (
                    <p key={attendee}>{attendee}</p>
                  ))}
                </div>
                <div className="flex gap-1 ">
                  {event.items.map((item) => (
                    <p key={item}>{item}</p>
                  ))}
                </div>
                <div className="flex justify-end">
                  <Link
                    href={`/app/events/event/${event.id}`}
                    className="px-3 py-2 bg-green-500"
                  >
                    {" "}
                    View Event
                  </Link>
                </div>
              </div>
            </div>
          ))}
        </div>
      </section>
      <section>
        <h2>Previous Events</h2>
        <div className="grid grid-cols-12 gap-4 pt-4">
          {events.map((event) => (
            <div key={event.id} className="flex col-span-6 ring">
              <div className="relative h-full aspect-square">
                <Image
                  src="https://images.unsplash.com/photo-1615887023544-3a566f29d822?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1287&q=80"
                  alt="event"
                  fill
                />
              </div>
              <div className="flex-1 p-4 ring">
                <p>{event.name}</p>
                <p>{event.description}</p>
                <p>{event.date}</p>
                <p>{event.location}</p>
                <p>{event.category}</p>
                <p>{event.host}</p>
                <div className="flex gap-1">
                  {event.attendees.map((attendee) => (
                    <p key={attendee}>{attendee}</p>
                  ))}
                </div>
                <div className="flex gap-1 ">
                  {event.items.map((item) => (
                    <p key={item}>{item}</p>
                  ))}
                </div>
                <div className="flex justify-end">
                  <Link
                    href={`/app/events/event/${event.id}`}
                    className="px-3 py-2 bg-green-500"
                  >
                    View Event
                  </Link>
                </div>
              </div>
            </div>
          ))}
        </div>
      </section>
    </main>
  );
}
