import { Status } from "./status.model";

export interface User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    mobileCountryCode: string;
    mobileNumber: string;
    status: Status;
  }
  