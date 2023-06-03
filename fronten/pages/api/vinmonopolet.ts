import {
  VinmonopoletProduct,
  VinmonopoletProductWithImage,
} from "models/vinmonopolet";

import { NextApiRequest, NextApiResponse } from "next";

interface Error {
  status: number;
  message: string;
}

const getVinmonopoletProductImage = (productId: string) => {
  return `https://bilder.vinmonopolet.no/cache/515x515-0/${productId}-1.jpg`;
};

export default async function handler(
  req: NextApiRequest,
  res: NextApiResponse<VinmonopoletProductWithImage[] | Error>
) {
  const { name, limit = 10, skip = 0 } = req.query;

  if (!name) {
    return res.status(400).json({
      status: 400,
      message: "Missing name query parameter",
    });
  }

  const results: VinmonopoletProduct[] = await fetch(
    `https://apis.vinmonopolet.no/products/v0/details-normal?productShortNameContains=${name}&maxResults=${limit}&start=${skip}`,
    {
      headers: {
        "Ocp-Apim-Subscription-Key": process.env.VINMONOPOLET_API_KEY as string,
      },
    }
  ).then((response) => {
    if (response.status === 200) {
      return response.json();
    } else {
      return [];
    }
  });

  const resultsWithImages: VinmonopoletProductWithImage[] = results.map(
    (result) => ({
      ...result,
      imageUrl: getVinmonopoletProductImage(result.basic.productId),
    })
  );

  res.status(200).json(resultsWithImages);
}
