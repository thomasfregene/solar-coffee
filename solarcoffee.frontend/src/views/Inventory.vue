<template>
    <div class="inventoryContainer">
        <h1 id="inventoryTitle">
            Inventory Dashboard
        </h1>
        <hr>

        <div>
            <solar-button @click.native="showNewProductModal" id="addnewBtn">
                Add New Item
            </solar-button>
            <solar-button @click.native="showShipmentModal" id="receiveShipmentBtn">
                Receive Shipment
            </solar-button>
        </div>


        <table id="InventoryTable" class="table">
            <tr>
                <th>Item</th>
                <th>Quantity On-hand</th>
                <th>Unit Price</th>
                <th>Taxable</th>
                <th>Delete</th>
            </tr>

            <tr v-for="item in inventory" :key="item.id">
                <td>
                    {{item.product.name}}
                </td>
                <td>
                    {{item.quantityOnHand}}
                </td>
                <td>
                    {{item.product.price | price}}
                </td>
                <td>
                    <span v-if="item.product.isTaxable">
                        Yes
                    </span>
                    <span v-else>
                        No
                    </span>
                </td>
                <td>
                    <div>
                        X
                    </div>
                </td>
            </tr>
        </table>
        <new-product-modal
         v-if="isNewProductVisible"
         @save:product="saveNewProduct"
         @close="closeModals"/>
        <shipment-modal 
        v-if="isShipmentVisible"
        @save:shipment="saveNewShipment"
        :inventory="inventory" 
        @close="closeModals"/>
    </div>

</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import{IProduct, IProductInventory} from '@/types/Product';
import SolarButton from '@/components/SolarButton.vue';
import NewProductModal from '@/components/modals/NewProductModal.vue';
import ShipmentModal from '@/components/modals/ShipmentModal.vue';
import { IShipment } from '@/types/Shipment';

import InventoryService from '@/services/inventory-service';

const inventoryService = new InventoryService();

@Component({
    name: 'Inventory',
    components: {SolarButton, NewProductModal, ShipmentModal}
})
export default class Inventory extends Vue{
    isNewProductVisible: boolean = false;
    isShipmentVisible: boolean = false;
    inventory: IProductInventory[] = [];

    closeModals(){
        this.isShipmentVisible = false;
        this.isNewProductVisible = false;
    }

    showNewProductModal(){
        this.isNewProductVisible = true;
    }

    showShipmentModal(){
        this.isShipmentVisible = true;
    }

    saveNewProduct(newProduct: IProduct){
        console.log('saveNewProduct:');
        console.log(newProduct);
    }

    async saveNewShipment(shipment:IShipment){
         await inventoryService.updateInventoryQuantity(shipment);
        this.isShipmentVisible = false;
        await this.fetchData(); //original video is initial()
    }

    async fetchData(){
        this.inventory = await inventoryService.getInventory();
    }

    async created(){
        await this.fetchData();
    }
}
</script>

<style lang="scss" scoped>

</style>