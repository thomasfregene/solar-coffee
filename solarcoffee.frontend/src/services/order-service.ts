import axios from 'axios';

export default class OrderService{
    API_URL = process.env.VUE_APP_API_URL;

    public async getOrders(): Promise<void>{
        let result: any = await axios.get(`${this.API_URL}/orders/`);
        return result.data;
    }

    public async makeOrderComplete(id: number): Promise<void>{
        let result: any = await axios.patch(`${this.API_URL}/orders/complete/${id}`);
        return result.data;
    }
}