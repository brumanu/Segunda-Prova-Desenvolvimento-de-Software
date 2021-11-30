import { ItemVenda } from './item-venda';
import { FormaPagamento } from './forma-pagamento';

export interface Venda{
    vendaId?: number;
    criadoEm?: string;
    itens?: ItemVenda[];
    cliente?: string;
    formaPagamento?: FormaPagamento;
    formaPagamentoId?: number;
}