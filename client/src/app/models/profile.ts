import { User } from "./user";

export interface Profile {
  username: string;
  displayName: string;
  bio: string;
}

export class Profile implements Profile {
  constructor(user: User) {
    this.username = user.username;
    this.displayName = user.displayName;
  }
}

export interface UserChronicDisease {
  id: string;
  name: string;
}

export interface UserAllergy {
  id: string;
  type: string;
  causes: string;
}

export interface UserVaccine {
  id: string;
  name: string;
  efficacy: string;
  creator: string;
  type: string;
}
export interface UserResult {
  id: string;
  result: string;
  testName: string;
  date: Date | null;
}
