import { IProductInventory } from '@/types/Product';
import axios from 'axios';
/**
 * Inventory Service.
 * Provides UI business logic associated with product inventory
 */
export default class InventoryService{
    API_URL = process.env.VUE_APP_API_URL;

    public async getInventory() : Promise<IProductInventory[]>{
        let result = await axios.get(`${this.API_URL}/inventory`);
        return result.data;
    }
}