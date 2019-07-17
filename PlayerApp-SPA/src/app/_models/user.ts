import { Photo } from './photo';

export interface User {
  photos: any;
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    city: string;
    country: string;
    // the following optional properties must come after required ones
    interests?: string;
    introduction?: string;
    lookingFor?: string;
    photo?: Photo[];
}
