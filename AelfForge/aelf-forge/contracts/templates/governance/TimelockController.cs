using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;
using System.Linq;

public class TimelockController : TimelockControllerContainer.TimelockControllerBase
{
    private readonly MapToUInt64<Transaction> _scheduledTransactions = new MapToUInt64<Transaction>();
    private readonly MappedSet<Address, Hash> _adminRoles = new MappedSet<Address, Hash>();

    public override Empty ScheduleTransaction(ScheduleTransactionInput input)
    {
        Assert(input.Eta > Context.CurrentBlockTime, "Eta must be in the future.");
        Assert(_adminRoles.Contains(Context.Sender, input.Role), "Not authorized.");

        var txId = input.Transaction.GetHash();
        _scheduledTransactions[txId] = input.Transaction;
        State.TransactionEta[txId] = input.Eta;
        return new Empty();
    }

    public override Empty ExecuteTransaction(Hash txId)
    {
        Assert(_scheduledTransactions.ContainsKey(txId), "Transaction not scheduled.");
        Assert(Context.CurrentBlockTime >= State.TransactionEta[txId], "Too early to execute.");
        Assert(_adminRoles.Contains(Context.Sender, _scheduledTransactions[txId].MethodName), "Not authorized.");

        Context.SendInline(_scheduledTransactions[txId].To, _scheduledTransactions[txId].MethodName,
            _scheduledTransactions[txId].Params);
        _scheduledTransactions.Remove(txId);
        State.TransactionEta.Remove(txId);
        return new Empty();
    }
    
    // ... Add functions for managing admin roles
}
