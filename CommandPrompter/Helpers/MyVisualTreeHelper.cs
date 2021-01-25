﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace CommandPrompter.Helpers
{
    public static class MyVisualTreeHelper
    {
        /// <summary>
        /// Return the first type-matched child.
        /// </summary>
        /// <typeparam name="F"></typeparam>
        /// <param name="d"></param>
        /// <returns></returns>
        public static F FindChildByType<F>(DependencyObject d) where F : DependencyObject
        {
            if (d == null)
                return null;

            var childCount = VisualTreeHelper.GetChildrenCount(d);

            for (var i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);

                var result = child as F ?? FindChildByType<F>(child);

                if (result != null)
                    return result;
            }
            return null;
        }
        //public static T FindChildByName<T>(DependencyObject parent, string childName) where T : DependencyObject
        //{
        //    // Confirm parent and childName are valid. 
        //    if (parent == null) return null;

        //    T foundChild = null;

        //    int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
        //    for (int i = 0; i < childrenCount; i++)
        //    {
        //        var child = VisualTreeHelper.GetChild(parent, i);
        //        // If the child is not of the request child type child
        //        T childType = child as T;
        //        if (childType == null)
        //        {
        //            // recursively drill down the tree
        //            foundChild = FindChildByName<T>(child, childName);

        //            // If the child is found, break so we do not overwrite the found child. 
        //            if (foundChild != null) break;
        //        }
        //        else if (!string.IsNullOrEmpty(childName))
        //        {
        //            var frameworkElement = child as FrameworkElement;
        //            // If the child's name is set for search
        //            if (frameworkElement != null && frameworkElement.Name == childName)
        //            {
        //                // if the child's name is of the request name
        //                foundChild = (T)child;
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            // child element found.
        //            foundChild = (T)child;
        //            break;
        //        }
        //    }

        //    return foundChild;
        //}
    }
}
