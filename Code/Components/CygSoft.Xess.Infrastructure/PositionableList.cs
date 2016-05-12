﻿using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Xess.Infrastructure
{
    public class PositionableList<T> where T : class, IPositionedItem
    {
        private const string ItemDoesNotExistMessage = "Position item does not exist within the position list.";
        private List<T> positionedItemList = new List<T>();

        public List<T> ItemsList
        {
            get
            {
                this.OrderAll();
                return positionedItemList;
            }
        }

        public T LastItem
        {
            get { return positionedItemList[positionedItemList.Count - 1]; }
        }

        public int Count { get { return positionedItemList.Count; } }

        public void Insert(T item)
        {
            if (positionedItemList.Count > 0)
            {
                item.Ordinal = (from ts in positionedItemList
                                select ts.Ordinal).Max() + 1;
            }
            else
                item.Ordinal = 1;

            positionedItemList.Add(item);
        }

        public bool CanMoveDown(T item)
        {
            if (!OrdinalMatchesReference(item))
                throw new NonMatchingOrdinalReferenceException(ItemDoesNotExistMessage);
            {
                int itemCount = positionedItemList.Count();

                if (itemCount > 1)
                {
                    if (item.Ordinal < itemCount)
                        return true;
                }
                return false;
            }
        }

        public bool CanMoveUp(T item)
        {
            if (!OrdinalMatchesReference(item))
                throw new NonMatchingOrdinalReferenceException(ItemDoesNotExistMessage);
            else
            {
                int itemCount = positionedItemList.Count();

                if (itemCount > 1)
                {
                    if (item.Ordinal > 1)
                        return true;
                }
                return false;
            }
        }

        public bool CanMoveTo(T item, int ordinal)
        {
            if (!OrdinalMatchesReference(item))
                throw new NonMatchingOrdinalReferenceException(ItemDoesNotExistMessage);
            else
            {
                return ordinal <= positionedItemList.Count && ordinal > 0 ? true : false;
            }
        }

        public void Remove(T item)
        {
            if (!OrdinalMatchesReference(item))
                throw new NonMatchingOrdinalReferenceException(ItemDoesNotExistMessage);

            else
            {
                int deleteOrdinal = item.Ordinal;
                positionedItemList.Remove(item);

                // fix ordinals.
                foreach (IPositionedItem posItem in positionedItemList)
                {
                    if (posItem.Ordinal > deleteOrdinal)
                        posItem.Ordinal = posItem.Ordinal - 1;
                }
                OrderAll();
            }
        }

        public void MoveUp(T item)
        {
            if (!OrdinalMatchesReference(item))
                throw new NonMatchingOrdinalReferenceException(ItemDoesNotExistMessage);

            else if (CanMoveUp(item))
            {
                T displacedItem = (from ts in positionedItemList
                                   where ts.Ordinal == item.Ordinal - 1
                                   select ts).SingleOrDefault();
                //swap
                item.Ordinal -= 1;
                displacedItem.Ordinal += 1;
            }
        }

        public void MoveDown(T item)
        {
            if (!OrdinalMatchesReference(item))
                throw new NonMatchingOrdinalReferenceException(ItemDoesNotExistMessage);

            else if (CanMoveDown(item))
            {
                T displacedItem = (from ts in positionedItemList
                                   where ts.Ordinal == item.Ordinal + 1
                                   select ts).SingleOrDefault();
                // swap
                item.Ordinal += 1;
                displacedItem.Ordinal -= 1;
            }
        }

        public void MoveTo(T item, int ordinal)
        {
            if (!OrdinalMatchesReference(item))
                throw new NonMatchingOrdinalReferenceException(ItemDoesNotExistMessage);
            else
            {
                int originalOrdinal = item.Ordinal;
                int newOrdinal = ordinal;
                // moving down...
                if (originalOrdinal < newOrdinal)
                {
                    foreach (T displacedItem in positionedItemList)
                    {
                        if (displacedItem.Ordinal > originalOrdinal && displacedItem.Ordinal <= newOrdinal)
                            displacedItem.Ordinal--;
                    }
                    item.Ordinal = newOrdinal;
                }
                else if (originalOrdinal > newOrdinal)
                {
                    foreach (T displacedItem in positionedItemList)
                    {
                        if (displacedItem.Ordinal < originalOrdinal && displacedItem.Ordinal >= newOrdinal)
                            displacedItem.Ordinal++;
                    }
                    item.Ordinal = newOrdinal;
                }
                // else the ordinal stays the same...

                OrderAll();
            }
        }

        public void InitializeList(List<T> itemList)
        {
            positionedItemList = itemList;
            AutoFixPositioning();
            OrderAll();
        }

        public bool ValidPositioning
        {
            get
            {
                OrderAll();

                int lastPosition = 0;
                for (int x = 0; x < positionedItemList.Count; x++)
                {
                    if (positionedItemList[x].Ordinal != lastPosition + 1)
                        return false;
                    lastPosition++;
                }
                return true;
            }
        }

        public void AutoFixPositioning()
        {
            OrderAll();

            int lastPosition = 0;
            foreach (IPositionedItem item in positionedItemList)
            {
                lastPosition++;
                item.Ordinal = lastPosition;
            }
        }

        public bool ExistsInList(T item)
        {
            return OrdinalMatchesReference(item);
        }

        private bool OrdinalMatchesReference(T item)
        {
            T positionedItem = (from ts in positionedItemList
                                where ts.Ordinal == item.Ordinal
                                select ts).SingleOrDefault();

            bool result = object.ReferenceEquals(positionedItem, item);
            return result;
        }

        private void OrderAll()
        {
            positionedItemList.Sort((x, y) => x.Ordinal.CompareTo(y.Ordinal));
        }
    }
}
