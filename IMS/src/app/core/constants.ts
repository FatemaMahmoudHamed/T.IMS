export abstract class Constants {
  static readonly BASE_URL: string = 'https://localhost:44390/'; 
  static readonly API_URL: string = Constants.BASE_URL + 'api/';
  
  // Endpoints
  static readonly INCIDENTS_API_URL: string = Constants.API_URL + 'incidents';
  static readonly CUSTOMERS_API_URL: string = Constants.API_URL + 'customers';
}
