import Image from "next/image";
import Link from "next/link";

interface Item {
  id: number;
  name: string;
  description: string;
  category: string;
  owner: string;
  event: string;
  rating: number;
}

export const getStaticProps = async () => {
  const dummyData = [
    {
      id: 1,
      name: "Item 1",
      description: "This is item 1",
      category: "Category 1",
      owner: "Owner 1",
      event: "Event 1",
      rating: 4.5,
    },
    {
      id: 2,
      name: "Item 2",
      description: "This is item 2",
      category: "Category 2",
      owner: "Owner 2",
      event: "Event 2",
      rating: 3.5,
    },
    {
      id: 3,
      name: "Item 3",
      description: "This is item 3",
      category: "Category 3",
      owner: "Owner 3",
      event: "Event 3",
      rating: 2.5,
    },
  ];

  return {
    props: {
      items: dummyData || [],
    },
  };
};

export default function ItemsPage({ items }: { items: Item[] }) {
  return (
    <main>
      <h1>Items Page</h1>
      <div>
        <p>List of all items</p>
        <p>Should be able to see details of an item</p>
      </div>
      <section className="grid grid-cols-12 gap-4">
        {items.map((item) => (
          <div key={item.id} className="col-span-2 ring">
            <div className="relative aspect-square">
              <Image
                src="https://images.unsplash.com/photo-1546540749-3229ce1f48da?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1287&q=80"
                alt="Item Image"
                fill
              />
            </div>
            <div className="p-4">
              <p>Name: {item.name}</p>
              <p>Description: {item.description}</p>
              <p>Category: {item.category}</p>
              <p>Owner: {item.owner}</p>
              <p>Event: {item.event}</p>
              <p>Rating: {item.rating}</p>
              <div className="flex justify-end mt-2">
                <Link
                  href={`/app/items/item/${item.id}`}
                  className="px-3 py-2 bg-green-500"
                >
                  View Item
                </Link>
              </div>
            </div>
          </div>
        ))}
      </section>
    </main>
  );
}
