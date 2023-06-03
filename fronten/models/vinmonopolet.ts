export interface VinmonopoletProduct {
  basic: {
    productId: string;
    productShortName: string;
  };
  lastChanged: {
    date: string;
    time: string;
  };
}

export interface VinmonopoletProductWithImage extends VinmonopoletProduct {
  imageUrl: string;
}

export interface RatingDocument extends VinmonopoletProductWithImage {
  ratedById: string;
  ratedFromGroupId: string;
  rating: number;
}
