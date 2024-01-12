using FastExpressionCompiler;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Playground.ExpressionTrees
{
    class ValidationHelper
    {
        public static void ThrowIfNullSimple<T>(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
        }

        public static void ThrowIfNull<T>(Expression<Func<T>> action)
        {
            T value = action.Compile()();

            var expression = (MemberExpression)action.Body;
            var exprName = expression.Member.Name;

            if (value == null)
                throw new ArgumentNullException(exprName);
        }

        public static void ThrowIfNullFast<T>(Expression<Func<T>> action)
        {
            T value = action.CompileFast()();

            var expression = (MemberExpression)action.Body;
            var exprName = expression.Member.Name;

            if (value == null)
                throw new ArgumentNullException(exprName);
        }

        public static void ThrowIfNullDescriptive<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;

            T value = action.Compile()();

            var expr = expression;
            var memberNames = new Stack<string>();
            while (expr != null)
            {
                memberNames.Push(expr.Member.Name);
                expr = expr.Expression as MemberExpression;
            }

            var exprName = string.Join(".", memberNames);

            if (value == null)
                throw new ArgumentNullException(exprName);
        }

        public static void ThrowIfNullDeep<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;

            var stack = new Stack<MemberExpression>();
            var expr = expression;
            while (expr != null)
            {
                stack.Push(expr);
                expr = expr.Expression as MemberExpression;
            }

            while (stack.Count > 0)
            {
                var memberExpr = stack.Pop();
                var exprName = memberExpr.Member.Name;
                var lambdaExpr = Expression.Lambda(memberExpr);
                Delegate myDelegate = lambdaExpr.Compile();
                var value = myDelegate.DynamicInvoke();

                if (value == null)
                    throw new ArgumentNullException(exprName);
            }
        }
    }
}
