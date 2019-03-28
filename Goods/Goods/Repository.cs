using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Goods
{
    public class JsonRepository<T> : IRepository<T>
    {
        public delegate void GoodsControl(string msgForCaller);
        public event GoodsControl GoodIsAdded;
        public event GoodsControl GoodIsNotAdded;
        //public delegate void GoodAlreadyExist();
        public void AddItem(T item)
        {            
            List<T> existsGoods = GetItemList();              
            if (existsGoods == null)
            {
                existsGoods = new List<T>{item};
                if (Serialize(existsGoods)) GoodIsAdded("Good is added");
                else GoodIsNotAdded("Good is not added");
            }
            else
            {
                existsGoods.Add(item);
                Serialize(existsGoods);
                GoodIsAdded("Good is added");
            }
        }
        public List<T> GetItemList()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            List<T> goodsList;
            if (File.Exists("File.json"))
                using (var stream = File.Open("File.json", FileMode.Open))
                {
                    return goodsList = (List<T>)jsonFormatter.ReadObject(stream);
                }
            else return goodsList = null;
        }
        private static bool Serialize(List<T> existsGoods)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));
            using (var stream = File.Open("File.json", FileMode.OpenOrCreate))
            {
                try
                {
                    jsonSerializer.WriteObject(stream, existsGoods);
                    return true;
                }
                catch{return false;}
                
            }
        }
        //private static bool CheckGood(List<T> existlist, T item, object obj)
        //{
        //    Predicate<T>
        //        obj.
        //}
    }
}


//public void AddItem(T item)
//{
//    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));
//    List<T> existsGoods = GetItemList();

//    if (existsGoods == null)
//    {
//        existsGoods = new List<T> { item };
//        using (var stream = File.Open("File.json", FileMode.OpenOrCreate))
//        {
//            try
//            {
//                jsonSerializer.WriteObject(stream, existsGoods);
//                GoodIsAdded("Good is added");
//            }
//            catch
//            {
//                GoodIsNotAdded("Good is not added");
//            }
//        }
//    }
//    else
//    {
//        existsGoods.Add(item);
//        using (var stream = File.Open("File.json", FileMode.Open))
//        {
//            jsonSerializer.WriteObject(stream, existsGoods);
//            GoodIsAdded("Good is added");
//        }
//    }
//}