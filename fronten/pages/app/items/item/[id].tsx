interface Item {
  id: number;
  name: string;
  description: string;
  category: string;
  owner: string;
  event: string;
  rating: number;
}

export async function getStaticPaths() {
  const paths = [
    { params: { id: "1" } },
    { params: { id: "2" } },
    { params: { id: "3" } },
  ];

  return {
    paths,
    fallback: false,
  };
}

export const getStaticProps = async () => {
  const dummyData = {
    id: 1,
    name: "Event 1",
    description: "This is event 1",
    date: "2021-01-01",
    location: "Location 1",
    category: "Category 1",
    host: "Host 1",
    attendees: ["Attendee 1", "Attendee 2"],
    items: ["Item 1", "Item 2"],
    rating: 4.5,
  };

  return {
    props: {
      item: dummyData || {},
    },
  };
};

export default function ItemPage({ item }: { item: any }) {
  return (
    <main>
      <h1>Item Page</h1>
      <div>
        <p>Should be able to see details of an item</p>
        <p>Should be able to view image of item</p>
        <p>Should be able to view name of item</p>
        <p>Should be able to view description of item</p>
        <p>Should be able to view category of item</p>
        <p>Should be able to view owner of item</p>
        <p>Should be able to view event of item</p>
      </div>
      <section className="ring">
        <h2>{item.name}</h2>
        <p>{item.description}</p>
        <p>{item.category}</p>
        <p>{item.owner}</p>
        <p>{item.event}</p>
        <p>{item.rating}</p>
      </section>
    </main>
  );
}
